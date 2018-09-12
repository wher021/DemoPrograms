
namespace Model
{
    public class Movie : IMovie
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }    
        }
    }
}
