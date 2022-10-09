using Microsoft.Extensions.Options;

namespace planete_biblio.IntefaceMethode
{
    public class Denis : Fidele
    {
        private readonly MyOptions _options;

        public Denis(IOptions<MyOptions> options)
        {
            _options = options.Value;
        }

        public void manger()
        {
            
        }
    }

    public class MyOptions
    {
        public int opt1 { get; set; }
        public int opt2 { get; set; }

        public MyOptions()
        {
            opt1 = 118;
            opt2 = 118;
        }
    }
}
