using Application.Account;
using System;

namespace Application.StudentFollow.Queries
{
    public class FollowDto
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsAccepte { get; set; }
        public int? CisStudentSendId { get; set; }
        public CisStudentDto CisStudentSend { get; set; }
        public int? CisStudentRecieveId { get; set; }
        public CisStudentDto CisStudentRecieve { get; set; }

    }
}