using NConsoleGraphics;

namespace OOPGame {

  public interface IGameObject {

    void Render(ConsoleGraphics graphics);

    void Update(GameEngine engine);

  }
}