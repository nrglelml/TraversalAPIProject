using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraversalApiProject.DAL.Context;
using TraversalApiProject.DAL.Entities;

namespace TraversalAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class VisitorController : ControllerBase
    {
        VisitorContext context = new VisitorContext();
        [HttpGet]
        public IActionResult VisitorList()
        {
            var values = context.Visitors.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult VisitorAdd(Visitor visitor)
        {
            context.Add(visitor);
            context.SaveChanges();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult VisitorGet(int id)
        {
            var values = context.Visitors.Find(id);
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(values);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteVisitor(int id)
        {
            var values = context.Visitors.Find(id);
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                context.Remove(values);
                context.SaveChanges();
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult UpdateVisitor(Visitor visitor)
        {
            var values = context.Find<Visitor>(visitor.VisitorID);
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                values.Name = visitor.Name;
                values.Surname = visitor.Surname;
                values.Mail = visitor.Mail;
                values.City = visitor.City;
                values.Country = visitor.Country;
                context.Update(values);
                context.SaveChanges();
                return Ok();
            }
        }

    }
}
