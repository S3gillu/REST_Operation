using REST_Operation.Models;
using REST_Operation.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;

namespace REST_Operation.Controllers
{
    public class MembersController : ApiController
    {
        private MemberContext db;
        public MembersController()
        {
            db = new MemberContext();
        }
        public IEnumerable<MemberDto> GetMembers()
        {
            return db.Members.ToList().Select(Mapper.Map<Member, MemberDto>);
        }
        public MemberDto GetMember(int id)
        {
            var member = db.Members.SingleOrDefault(c => c.MemId == id);
            if (member == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Member, MemberDto>(member);

        }
        [HttpPost]


        //Post Operation
        public IHttpActionResult CreateMember(MemberDto memberDto)
        {
            if (!ModelState.IsValid)
               
                return BadRequest();
            var member = Mapper.Map<MemberDto, Member>(memberDto);
            db.Members.Add(member);
            db.SaveChanges();
            memberDto.MemId = member.MemId;
            return Created(new Uri(Request.RequestUri + "/" + member.MemId), memberDto);
          
        }
        [HttpPut]
        //Put Operation
        public void UpdateMember(int id, MemberDto memberDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var memberInDb = db.Members.SingleOrDefault(c => c.MemId == id);
            if (memberInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(memberDto, memberInDb);
           
            db.SaveChanges();


        }
        [HttpDelete]
        //Delete Operation
        public void DeleteMember(int id)
        {
            var memberInDb = db.Members.SingleOrDefault(c => c.MemId == id);
            if (memberInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            db.Members.Remove(memberInDb);
            db.SaveChanges();
        }
    }
}
