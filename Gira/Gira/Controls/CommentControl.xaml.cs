using Gira.Classes;
using System.Windows.Controls;

namespace Gira.Controls
{
    /// <summary>
    /// Interaction logic for CommentControl.xaml
    /// </summary>
    public partial class CommentControl : UserControl
    {
        public readonly Comment Comment;
        public CommentControl(Comment comment)
        {
            InitializeComponent();

            Comment = comment;

            SetCommentProperties();
        }

        private void SetCommentProperties()
        {
            tbkOwner.Text = Comment.Owner.Name;
            tbkDate.Text = Comment.Created.ToString();
            tbkComment.Text = Comment.Text;
        }
    }
}
