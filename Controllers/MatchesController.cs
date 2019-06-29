using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CricAPI.Models;

namespace CricAPI.Controllers{
    
    
    [ApiController]
    public class MatchesController: ControllerBase{

        private readonly CricsheetContext _context;

        public MatchesController(CricsheetContext context)
        {
            _context = context;
        }
        
        [Route("[controller]/GetAll")]
        [HttpGet]
        public async Task<ActionResult<List<Matches>>> GetAllMatches(int skip = 0, int top = 10)
        {
            //Set Max PageSize to 10
            if (top > 10 || top < 0)
            {
                top = 10;
            }
            return await _context.Matches.AsNoTracking().FromSql($"select * from matches order by matchdata->'info'->'dates'->>0 desc").Skip(skip).Take(top).ToListAsync();
        }

        [Route("[controller]/GetById/{cricSheetId}")]
        [HttpGet]
        public async Task<ActionResult<Matches>> GetMatchById(long? cricSheetId)
        {

            if(cricSheetId == null || cricSheetId <=0)
            {
                return BadRequest();
            }

            return await _context.Matches.AsNoTracking().Where(b => b.Cricsheetid == cricSheetId).FirstOrDefaultAsync();
        }

        [Route("[controller]/GetByTeam/{teamName}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Matches>>>  GetMatchesByTeam(string teamName, int top = 10, int skip = 0)
        {

            if(teamName == null || teamName == "")
            {
                return BadRequest();
            }
            //Set Max PageSize to 10
            if (top > 10 || top < 0)
            {
                top = 10;
            }
            
            return await _context.Matches.AsNoTracking().FromSql($"select cricsheetid, matchdata from matches where (lower(matchdata->'info'->'teams'->>0) = {teamName.ToLower()} or lower(matchdata->'info'->'teams'->>1) = {teamName.ToLower()}) order by matchdata->'info'->'dates'->>0 desc").Skip(skip).Take(top).ToListAsync();
        }

        [Route("[controller]/GetByType/{type}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Matches>>>  GetMatchesByType(string type, int top = 10, int skip = 0)
        {

            //Set Max PageSize to 10
            if (top > 10 || top < 0)
            {
                top = 10;
            }
            return await _context.Matches.AsNoTracking().FromSql($"select cricsheetid, matchdata from matches where lower(matchdata->'info'->>'match_type') = {type.ToLower()} order by matchdata->'info'->'dates'->>0 desc").Skip(skip).Take(top).ToListAsync();
        }

        [Route("[controller]/GetByYear/{year}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Matches>>>  GetMatchesByYear(int year, int top = 10, int skip = 0)
        {
            string fd = new System.DateTime(year, 01, 01).ToString("yyyy-MM-dd");
            string ld = new System.DateTime(year, 12, 31).ToString("yyyy-MM-dd");

            //Set Max PageSize to 10
            if (top > 10 || top < 0)
            {
                top = 10;
            }
            return await _context.Matches.AsNoTracking().FromSql($"select cricsheetid, matchdata from matches where (matchdata->'info'->'dates'->>0) > {fd} and (matchdata->'info'->'dates'->>0) < {ld} order by matchdata->'info'->'dates'->>0 desc").Skip(skip).Take(top).ToListAsync();
        }

        [Route("[controller]/GetBWTeams")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Matches>>>  GetMatchesBWTeam(string team1, string team2, int top = 10, int skip = 0)
        {

            if((team1 == null || team1 == "") || (team2==null || team2 == ""))
            {
                return BadRequest();
            }
            //Set Max PageSize to 10
            if (top > 10 || top < 0)
            {
                top = 10;
            }
               
            return await _context.Matches.AsNoTracking().FromSql($"select cricsheetid, matchdata from matches where ((lower(matchdata->'info'->'teams'->>0) = {team1.ToLower()} or lower(matchdata->'info'->'teams'->>1) = {team1.ToLower()}) and (lower(matchdata->'info'->'teams'->>0) = {team2.ToLower()} or lower(matchdata->'info'->'teams'->>1) = {team2.ToLower()})  ) order by matchdata->'info'->'dates'->>0 desc").Skip(skip).Take(top).ToListAsync();
        }
    }
}