namespace Blog.Test.Fakes
{
    using Blog.Services;

    public class FakeRandomService : IRandomService
    {
        private readonly int randomNumber;

        public FakeRandomService(int randomNumber)
            => this.randomNumber = randomNumber;

        public int Next(int min, int max) => this.randomNumber;
    }
}
