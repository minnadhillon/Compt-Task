using MarsFramework.Pages;
using NUnit.Framework;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {

            [Test]
            public void Shareskill()
            {
                ShareSkill save = new ShareSkill();
                save.SaveShareSkill();


            }
            [Test]
            public void Edit()
            {
                ManageListings l1 = new ManageListings();
                l1.ListingsEdit();

            }
            [Test]
            public void Delete()
            {
                ManageListings l2 = new ManageListings();
                l2.ListingsDelete();
            }


        }
    }
}