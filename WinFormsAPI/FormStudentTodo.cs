namespace StudentAPI
{
    internal class ToDo
    {
        public int userId { get ; set ; }
        public int id { get ; set ; }
        public string title { get ; set ; }
        public bool completed { get ; set ; }

        public override string ToString ()
        {
        return $"User Id: {userId},\tId: {id},\tTitle: {title, -15},\tCompleted: {completed}";
        }
    }
}