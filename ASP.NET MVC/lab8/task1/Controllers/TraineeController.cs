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
    public class TraineeController : Controller
    {
        private readonly TraineeRepository _traineeRepository;
        private readonly TrackRepository _trackRepository;

        public TraineeController(TraineeRepository traineeRepository, TrackRepository trackRepository)
        {
            _traineeRepository = traineeRepository;
            _trackRepository = trackRepository;
        }

        // GET: Trainee
        public IActionResult Index()
        {
            return View(_traineeRepository.GetAllWithTrack());
     }

        // GET: Trainee/Details/5
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainee = _traineeRepository.GetByIdWithTrack(id);

            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        // GET: Trainee/Create
        public IActionResult Create()
        {
            ViewData["Tracks"] = new SelectList(_trackRepository.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Trainee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Gender,Email,PhoneNumber,Birthdate,TrackId")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                _traineeRepository.Add(trainee);
                return RedirectToAction(nameof(Index));
            }

            ViewData["Tracks"] = new SelectList(_trackRepository.GetAll(), "Id", "Name", trainee.TrackId);

            return View(trainee);
        }

        // GET: Trainee/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainee = _traineeRepository.GetByIdWithTrack(id);
            if (trainee == null)
            {
                return NotFound();
            }

            ViewData["Tracks"] = new SelectList(_trackRepository.GetAll(), "Id", "Name", trainee.TrackId);

            return View(trainee);
        }

        // POST: Trainee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Gender,Email,PhoneNumber,Birthdate,TrackId")] Trainee trainee)
        {
            if (id != trainee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _traineeRepository.Update(trainee);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TraineeExists(trainee.Id))
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

            ViewData["Tracks"] = new SelectList(_trackRepository.GetAll(), "Id", "Name", trainee.TrackId);

            return View(trainee);
        }

        // GET: Trainee/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainee = _traineeRepository.GetByIdWithTrack(id);

            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        // POST: Trainee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([Bind("Id")] Trainee trainee)
        {
            _traineeRepository.DeleteById(trainee.Id);

            return RedirectToAction(nameof(Index));
        }

        private bool TraineeExists(int id)
        {
            return _traineeRepository.GetAll().Any(e => e.Id == id);
        }
    }
}
