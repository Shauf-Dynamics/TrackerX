﻿namespace TrackerX.Domain.Entities
{
    public class Band : BaseEntity
    {
        public int Id { get; set; }

        public int Name { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
