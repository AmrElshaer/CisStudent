using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.StudentPost.Commonds.DeletePost
{
    public class DeletePostCommond:IRequest
    {
        public int Id { get; set; }
    }
}
