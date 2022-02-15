using System.Threading.Tasks;

public interface IUIPanel
{
   void Show();
   void Hide();
   Task<bool> ShowAnimAsync();
   Task<bool> HideAnimAsync();
}
