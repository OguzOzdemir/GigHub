using GigHub.Models;
using System.Collections.Generic;

namespace GigHub.Repositories
{
    public interface IGigRepository
    {
        Gig GetGig(int gigId);
        IEnumerable<Gig> GetUpComingGigsByArtist(string artistId);
        Gig GetGigWithAttendees(int gigId);
        IEnumerable<Gig> GetGigsUserAttending(string userId);
        void Add(Gig gig);
    }
}
