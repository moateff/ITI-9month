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
    public class TraineeCourseController : Controller
    {
        private readonly TraineeCourseRepository _traineeCourseRepository;
        private readonly TraineeRepository _traineeRepository;
        private readonly CourseRepository _courseRepository;

        public TraineeCourseController(TraineeCourseRepository traineeCourseRepository, TraineeRepository traineeRepository, CourseRepository courseRepository)
        {
            _traineeCourseRepository = traineeCourseRepository;
            _traineeRepository = traineeRepository;
            _courseRepository = courseRepository;
        }

        // GET: TraineeCourse
        public IActionResult Index()
        {
            return View(_traineeCourseRepository.GetAllWithTraineeAndCourse());
        }

        // GET: TraineeCourse/Details/5
        public IActionResult Details(int traineeId, int courseId)
        {
            if (traineeId == null || courseId == null)
            {
                return NotFound();
            }

            var traineeCourse = _traineeCourseRepository.GetByIdWithTraineeAndCourse(traineeId, courseId);

            if (traineeCourse == null)
            {
                return NotFound();
            }

            return View(traineeCourse);
        }

        // GET: TraineeCourse/Create
        public IActionResult Create()
        {
            ViewData["Courses"] = new SelectList(_courseRepository.GetAll(), "Id", "Topic");
            ViewData["Trainees"] = new SelectList(_traineeRepository.GetAll(), "Id", "Name");
            return View();
        }

        // POST: TraineeCourse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("TraineeId,CourseId,Grade")] TraineeCourse traineeCourse)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _traineeCourseRepository.Add(traineeCourse);
                }
                catch (DbUpdateException)
                {
                    if (TraineeCourseExists(traineeCourse.TraineeId, traineeCourse.CourseId))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["Courses"] = new SelectList(_courseRepository.GetAll(), "Id", "Topic", traineeCourse.CourseId);
            ViewData["Trainees"] = new SelectList(_traineeRepository.GetAll(), "Id", "Name", traineeCourse.TraineeId);

            return View(traineeCourse);
        }

        // GET: TraineeCourse/Edit/5
        public IActionResult Edit(int traineeId, int courseId)
        {
            if (traineeId == null || courseId == null)
            {
                return NotFound();
            }

            var traineeCourse = _traineeCourseRepository.GetByIdWithTraineeAndCourse(traineeId, courseId);

            if (traineeCourse == null)
            {
                return NotFound();
            }

            ViewData["Courses"] = new SelectList(_courseRepository.GetAll(), "Id", "Topic", traineeCourse.CourseId);
            ViewData["Trainees"] = new SelectList(_traineeRepository.GetAll(), "Id", "Name", traineeCourse.TraineeId);

            return View(traineeCourse);
        }

        // POST: TraineeCourse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int traineeId, int courseId, [Bind("TraineeId,CourseId,Grade")] TraineeCourse traineeCourse)
        {
            if (traineeId != traineeCourse.TraineeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _traineeCourseRepository.Update(traineeCourse);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TraineeCourseExists(traineeCourse.TraineeId, traineeCourse.CourseId))
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

            ViewData["Courses"] = new SelectList(_courseRepository.GetAll(), "Id", "Topic", traineeCourse.CourseId);
            ViewData["Trainees"] = new SelectList(_traineeRepository.GetAll(), "Id", "Name", traineeCourse.TraineeId);
            
            return View(traineeCourse);
        }

        // GET: TraineeCourse/Delete/5
        public IActionResult Delete(int traineeId, int courseId)
        {
            if (traineeId == null || courseId == null)
            {
                return NotFound();
            }

            var traineeCourse = _traineeCourseRepository.GetByIdWithTraineeAndCourse(traineeId, courseId);

            if (traineeCourse == null)
            {
                return NotFound();
            }

            return View(traineeCourse);
        }

        // POST: TraineeCourse/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([Bind("TraineeId","CourseId")] TraineeCourse traineeCourse)
        {
            _traineeCourseRepository.DeleteByIdWithTraineeAndCourse(traineeCourse.TraineeId, traineeCourse.CourseId);

            return RedirectToAction(nameof(Index));
        }

        private bool TraineeCourseExists(int traineeId, int courseId)
        {
            return _traineeCourseRepository.GetAllWithTraineeAndCourse().Any(t => t.TraineeId == traineeId && t.CourseId == courseId);
        }
    }
}
