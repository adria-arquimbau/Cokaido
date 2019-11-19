using System.Collections.Generic;

namespace TwitKaidoKata
{
    public class Post
    {
        private readonly List<string> _posts;

        public Post(List<string> posts)
        {
            _posts = posts;
        }

        protected bool Equals(Post other)
        {
            if (this._posts.Count != other._posts.Count)
            {
                return false;
            }

            foreach (var post in _posts)
            {
                if (!other._posts.Contains(post)) return false;
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Post) obj);
        }

        public override int GetHashCode()
        {
            return (_posts != null ? _posts.GetHashCode() : 0);
        }
    }
}