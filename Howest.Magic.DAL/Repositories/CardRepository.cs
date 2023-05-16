﻿using Microsoft.EntityFrameworkCore;

namespace Howest.MagicCards.DAL.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly MtgDbContext _dbContext;

        public CardRepository(MtgDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Card>> GetCards()
        {
            return await _dbContext.Cards
                .Include(c => c.SetCodeNavigation)
                .Include(c => c.RarityCodeNavigation)
                .Include(c => c.CardColors)
                    .ThenInclude(cc => cc.Color)
                .Include(c => c.CardTypes)
                    .ThenInclude(ct => ct.Type)
                .Select(c => c)
                .ToListAsync();
        }

        public async Task<Card> GetCardById(long id)
        {
            return await _dbContext.Cards
                .Include(c => c.SetCodeNavigation)
                .Include(c => c.RarityCodeNavigation)
                .Include(c => c.CardColors)
                    .ThenInclude(cc => cc.Color)
                .Include(c => c.CardTypes)
                    .ThenInclude(ct => ct.Type)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Card>> GetCardsByArtistId(long artistId)
        {
            return await _dbContext.Cards
               .Include(c => c.SetCodeNavigation)
               .Include(c => c.RarityCodeNavigation)
               .Include(c => c.CardColors)
                   .ThenInclude(cc => cc.Color)
               .Include(c => c.CardTypes)
                   .ThenInclude(ct => ct.Type)
               .Where(c => c.ArtistId == artistId)
               .ToListAsync();
        }
    }
}
