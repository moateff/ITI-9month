using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using task1.Models;
using task1.Repositories;


namespace task1.Controllers
{
    [Route("api/tracks")]
    public class TrackController : Controller
    {
        private readonly TrackRepository _repository;

        public TrackController(TrackRepository repository)
        {
            _repository = repository;
        }

        // GET: Track
        [Route("")]
        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }

        // GET: Track/Details/5
        [Route("{id:int}")]
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = _repository.GetById(id);
            
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        // GET: Track/Create
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Track/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("create")]
        public IActionResult Create([Bind("Id,Name,Description")] Track track)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(track);
                return RedirectToAction(nameof(Index));
            }
            return View(track);
        }

        // GET: Track/Edit/5
        [Route("edit/{id:int}")]
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = _repository.GetById(id);

            if (track == null)
            {
                return NotFound();
            }
            return View(track);
        }

        // POST: Track/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit/{id:int}")]
        public IActionResult Edit(int id, [Bind("Id,Name,Description")] Track track)
        {
            if (id != track.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Update(track);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrackExists(track.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(track);
        }

        // GET: Track/Delete/5
        [Route("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = _repository.GetById(id);

            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        // POST: Track/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("delete/{id:int}")]
        public IActionResult Delete([Bind("Id")] Track track)
        {
            _repository.DeleteById(track.Id);

            return RedirectToAction(nameof(Index));
        }

        private bool TrackExists(int id)
        {
            return _repository.GetAll().Any(e => e.Id == id);
        }
    }
}
