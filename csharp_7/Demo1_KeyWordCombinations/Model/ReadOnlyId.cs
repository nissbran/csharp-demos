using System;

namespace Demo1_KeyWordCombinations.Model
{
    public readonly struct ReadOnlyId : IEquatable<ReadOnlyId>
    {
        public Guid Id { get; }
        //public Guid Id { get; set; }

        private readonly Guid _id;
        //private Guid _id;
        
        public ReadOnlyId(Guid id)
        {
            Id = id;
            _id = id;
        }

        public bool Equals(ReadOnlyId other)
        {
            return Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is ReadOnlyId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}