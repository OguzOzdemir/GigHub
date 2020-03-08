using GigHub.Core.Models;
using GigHub.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GigHub.Persistence.Repositories
{
    public class GigRepository : IGigRepository
    {
        private readonly ApplicationDbContext _context;

        public GigRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Gig GetGig(int gigId)
        {
            return _context.Gigs.Include(x => x.Artist).Include(x => x.Genre).SingleOrDefault(x => x.Id == gigId);
        }

        public IEnumerable<Gig> GetUpComingGigsByArtist(string artistId)
        {
            return _context.Gigs.Where(x => x.ArtistId == artistId && x.DateTime > DateTime.Now && !x.IsCanceled).Include(x => x.Genre).ToList();
        }

        public Gig GetGigWithAttendees(int gigId)
        {
            return _context.Gigs
                .Include(x => x.Attendances.Select(a => a.Attendee))
                .SingleOrDefault(x => x.Id == gigId);
        }

        public IEnumerable<Gig> GetGigsUserAttending(string userId)
        {
            return _context.Attendances
               .Where(x => x.AttendeeId == userId)
               .Select(x => x.Gig)
               .Include(x => x.Artist)
               .Include(x => x.Genre)
               .ToList();
        }

        public void Add(Gig gig)
        {
            _context.Gigs.Add(gig);
        }
    }
}