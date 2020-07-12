﻿using Microsoft.EntityFrameworkCore;
using System.Linq;
using ProjectManagement.Data;
using ProjectManagement.ViewModel;

namespace ProjectManagement.Services
{
    public class BoardService
    {
        private readonly ProjectManagementDbContext _dbContext;

        public BoardService(ProjectManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BoardList ListBoard()
        {
            var model = new BoardList();

            foreach (var board in _dbContext.Boards)
            {
                model.Boards.Add(new BoardList.Board
                {
                    Id = board.Id,
                    Title = board.Title
                });
            }

            return model;
        }

        public BoardView GetBoard(int id)
        {
            var model = new BoardView();

            var board = _dbContext.Boards
                .Include(b => b.Columns)
                .ThenInclude(c => c.Cards)
                .SingleOrDefault(x => x.Id == id);

            if (board == null) return model;
            model.Id = board.Id;

            foreach (var column in board.Columns)
            {
                var modelColumn = new BoardView.Column
                {
                    Title = column.Title,
                    Id = column.Id
                };

                foreach (var card in column.Cards)
                {
                    var modelCard = new BoardView.Card
                    {
                        Id = card.Id,
                        Content = card.Contents
                    };

                    modelColumn.Cards.Add(modelCard);
                }

                model.Columns.Add(modelColumn);
            }

            return model;
        }

        public void AddCard(AddCard viewModel)
        {
            var board = _dbContext.Boards
                .Include(b => b.Columns)
                .SingleOrDefault(x => x.Id == viewModel.Id);

            if (board != null)
            {
                var firstColumn = board.Columns.FirstOrDefault();
                var secondColumn = board.Columns.FirstOrDefault();
                var thirdColumn = board.Columns.FirstOrDefault();
            
                if (firstColumn == null || secondColumn == null || thirdColumn == null)
                {
                    firstColumn = new Models.Column { Title = "Yapılıyor"};
                    secondColumn = new Models.Column { Title = "Yapıldı" };
                    thirdColumn = new Models.Column { Title = "Yapılacak" };
                    board.Columns.Add(firstColumn);
                    board.Columns.Add(secondColumn);
                    board.Columns.Add(thirdColumn);
                }

                firstColumn.Cards.Add(new Models.Card
                {
                    Contents = viewModel.Contents
                });
            }

            _dbContext.SaveChanges();
        }

        public void AddBoard(NewBoard viewModel)
        {
            _dbContext.Boards.Add(new Models.Board
            {
                Title = viewModel.Title
            });

            _dbContext.SaveChanges();
        }

        public void Move(MoveCardCommand command)
        {
            var card = _dbContext.Cards.SingleOrDefault(x => x.Id == command.CardId);
            if (card != null) card.ColumnId = command.ColumnId;
            _dbContext.SaveChanges();
        }
    }
}
