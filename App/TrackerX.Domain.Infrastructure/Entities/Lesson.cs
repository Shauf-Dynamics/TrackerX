using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerX.Domain.Entities
{
    public class Lesson : BaseEntity
    {
        public int LessonId { get; set; }

        public DateTime LessonDate { get; set; }
    }
}
