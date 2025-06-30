using eLearning.WebApp.Client.Models;

namespace eLearning.WebApp.Client.Services
{
    public class CartService
    {
        private List<CourseModel> _items = new();

        public IReadOnlyList<CourseModel> Items => _items.AsReadOnly();

        public event Action? OnChange;

        public void SetCart(List<CourseModel> cart)
        {
            _items = cart;
            NotifyStateChanged();
        }

        public void AddToCart(CourseModel course)
        {
            _items.Add(course);
            NotifyStateChanged();
        }

        public void RemoveFromCart(Guid courseId)
        {
            _items.RemoveAll(c => c.Id == courseId);
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
