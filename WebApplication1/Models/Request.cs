namespace WebApplication1.Models
{
    public class Request
    {
        public ExerciseType ExerciseType { get; }
        public IList<string> RequestDatas { get; }

        public Request(ExerciseType exerciseType, IList<string> requestDatas) 
        { 
            ExerciseType = exerciseType;
            RequestDatas = requestDatas;
        }
    }
}
