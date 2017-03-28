﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Chess.WebAPI.Models;

namespace Chess.WebAPI.Controllers
{
    public class BoardstatesController : ApiController
    {
        private ChessWebAPIContext db = new ChessWebAPIContext();

        // GET: api/Boardstates
        public IQueryable<BoardstatesDTO> GetBoardstates()
        {
            var board = from b in db.Boardstates
                        select new BoardstatesDTO(b);

            return board;
            //return db.Boardstates.Include(g => g.GameId);
        }

        // GET: api/Boardstates/5
        [ResponseType(typeof(Boardstates))]
        public async Task<IHttpActionResult> GetBoardstates(int id)
        {
            var board = await db.Boardstates.Include(b => b.StateId).Select(b => new BoardstatesDTO(b)).SingleOrDefaultAsync(b => b.StateId == id);
            Boardstates boardstates = await db.Boardstates.FindAsync(id);
            if (boardstates == null)
            {
                return NotFound();
            }

            return Ok(boardstates);
        }

        // PUT: api/Boardstates/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBoardstates(int id, Boardstates boardstates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != boardstates.StateId)
            {
                return BadRequest();
            }

            db.Entry(boardstates).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardstatesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // probablly not needed
        /*// POST: api/Boardstates
        [ResponseType(typeof(Boardstates))]
        public async Task<IHttpActionResult> PostBoardstates(Boardstates boardstates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Boardstates.Add(boardstates);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = boardstates.StateId }, boardstates);
        }

        // DELETE: api/Boardstates/5
        [ResponseType(typeof(Boardstates))]
        public async Task<IHttpActionResult> DeleteBoardstates(int id)
        {
            Boardstates boardstates = await db.Boardstates.FindAsync(id);
            if (boardstates == null)
            {
                return NotFound();
            }

            db.Boardstates.Remove(boardstates);
            await db.SaveChangesAsync();

            return Ok(boardstates);
        }*/

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BoardstatesExists(int id)
        {
            return db.Boardstates.Count(e => e.StateId == id) > 0;
        }

        // get board by ids
        public Boardstates GetStateById(int sId)
        {
            return db.Boardstates.SingleOrDefault(x => x.StateId == sId);
        }

        // add new state to bs
        public void AddState(Board b)
        {
            Boardstates bs = new Boardstates();
            // will get one state
            // compare it to the last state in the db
            // with Chris's method
            // if true or whatever, then add the state
            // if not true, don't
            // make this return a boolean instead
            //bs.Game = GetGameById(gId);
            /*bs.GameId = gId;
            bs.StateId = sId;
            bs.State = state;*/
            b.
            //bs.Timestamp = DateTime.Now;

            db.Boardstates.Add(bs);
            db.SaveChanges();
        }
    }
    public class Board
    {
        Team turn;
        public Piece[,] board;
    }
    public enum PieceType
    {
        pawn, rook, knight, bishop, king, queen, error = 0
    }
    public enum Team
    {
        black, white, error = 0
    }
    public class Piece
    {
        Team Team;
        PieceType Name;
        bool HasMoved;

        public Piece(Team t, PieceType n)
        {
            Team = t;
            Name = n;
            HasMoved = false;
        }

        public Team getTeam()
        {
            return Team;
        }

        public PieceType getName()
        {
            return Name;
        }
        public bool getHasMoved()
        {
            return HasMoved;
        }
        public void setHasMoved()
        {
            HasMoved = true;
        }
        public Piece copy()
        {
            return new Piece(Team, Name);
        }
    }
}