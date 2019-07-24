using iSalesDeskPlus.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iSalesDeskPlus.ViewModels
{
    public class WelcomeViewModel : BindableBase
    {
        public WelcomeViewModel()
        {
            CarouselItems = new List<WelcomePage>{
                new WelcomePage { ImageUrl="stock.jpg", Title="Welcome", Subtitle="TO THIS TASTEFUL LOOKING TUTORIAL", Text="Just look at that awesome plate filled with tomatoes, rucola and some sort of white coleslaw looking thing. I don't like coleslaw. Really don't."},
                new WelcomePage { ImageUrl="stock2.jpg", Title="Churros!", Subtitle="YOU GOTTA LOVE THESE", Text="Churros oh churros, my favorite cakes, dipped in cinnamon and oh so sweet. Some are long, some are short, but they are all tasty and that's why I love them."},
                new WelcomePage { ImageUrl="stock3.jpg", Title="Muffins", Subtitle="THEY LOOK LIKE CAKES", Text="I love you with coffee, I love you with tea, I love that you're so very yummy. Don't care if you're iced, topped with crumbles, or bare As long as you get in my tummy."},
            };
        }

        public List<WelcomePage> CarouselItems { get; set; }
    }
}
