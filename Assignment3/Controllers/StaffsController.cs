using Antlr.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment3.Controllers
{
    public class StaffsController : ApiController
    {
        public IHttpActionResult GetAllStaffs()
        {
            IList<Staff> staffs = null;

            using (var ctx = new StaffsEntities())
            {
                staffs = ctx.Staffs.ToList<Staff>();
            }

            if (staffs.Count == 0)
            {
                return NotFound();
            }

            return Ok(staffs);
        }
        public IHttpActionResult GetStaffById(int id)
        {
            Staff staffs = null;

            using (var ctx = new StaffsEntities())
            {
                staffs = ctx.Staffs.Where(s => s.staff_id == id).FirstOrDefault<Staff>();
            }

            if (staffs == null)
            {
                return NotFound();
            }

            return Ok(staffs);
        }
        public IHttpActionResult PostNewStaff(Staff staffs)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new StaffsEntities())
            {
                ctx.Staffs.Add(new Staff()
                {
                    first_name = staffs.first_name,
                    last_name = staffs.last_name,
                    email = staffs.email,
                    phone = staffs.phone,
                    active = staffs.active,
                    store_id = staffs.store_id
                });

                ctx.SaveChanges();
            }

            return Ok();
        }
        public IHttpActionResult Put(Staff staffs)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new StaffsEntities())
            {
                var existingStaff = ctx.Staffs.Where(s => s.staff_id == staffs.staff_id).FirstOrDefault<Staff>();
                if (existingStaff != null)
                {
                    existingStaff.first_name = staffs.first_name;
                    existingStaff.last_name = staffs.last_name;
                    existingStaff.email = staffs.email;
                    existingStaff.phone = staffs.phone;
                    existingStaff.active = staffs.active;
                    existingStaff.store_id = staffs.store_id;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }

            }
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid staff id");

            using (var ctx = new StaffsEntities())
            {
                var staffs = ctx.Staffs.Where(s => s.staff_id == id).FirstOrDefault();

                ctx.Entry(staffs).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }

            return Ok();
        }
    }
}
