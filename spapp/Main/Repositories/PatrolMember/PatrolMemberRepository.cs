﻿using spapp.Http.Requests;
using spapp.Models;
using spapp.SpappContext;

namespace spapp.Main.Repositories.PatrolMember
{
    public class PatrolMemberRepository(SpappContextDb spappContextDb) : IPatrolMemberRepository
    {
        private readonly SpappContextDb _spappContextDb = spappContextDb;
        public void Create(PatrolRequest request, PatrolModel patrol)
        {
            

            if ( request.MembersId is not null)
            {             
                foreach (int id in request.MembersId )
                {
                    if (id != request.DriverId)
                    {
                        PatrolMemberModel member = new()
                        {
                            PatrolId = patrol.Id,
                            AgentId = id,
                            Created_at = DateTime.Now,
                        };

                        _spappContextDb.PatrolMembers.Add(member);
                        _spappContextDb.SaveChanges();
                    }
                    continue;
                    
                }
            }
        }
    }
}
