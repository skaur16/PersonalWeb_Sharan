namespace PersonalWeb_Sharan.Models
{
    public class CommentViewModel
    {
        public Comment NewComment { get; set; } = new Comment { Name = string.Empty, Text = string.Empty }; // Initializes with a new Comment
        public List<Comment> Comments { get; set; } = new List<Comment>(); // Initializes with an empty list
    }
}
