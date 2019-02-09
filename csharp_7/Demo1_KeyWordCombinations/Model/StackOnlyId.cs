using System;
using System.ComponentModel;

namespace Demo1_KeyWordCombinations.Model
{
    public readonly ref struct StackOnlyId
    {
        public Guid Id { get; }
        //public Guid Id { get; set; }

        private readonly Guid _id;
        //private Guid _id;
        
        public StackOnlyId(Guid id)
        {
            Id = id;
            _id = id;
        } 
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => throw new NotSupportedException();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => throw new NotSupportedException();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => throw new NotSupportedException();
    }
}