namespace Demo1_KeyWordCombinations.Model
{
    public class MyClass
    {
        public ReadOnlyId Id { get; }
        
        //public StackOnlyId Id2 { get; }
        
        public MyClass(ReadOnlyId id)
        {
            Id = id;
        }
    }
}