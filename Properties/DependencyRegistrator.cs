using Rocket.API.Commands;
using Rocket.API.DependencyInjection;

namespace fr34kyn01535.MessageAnnouncer.Properties
{
    public class DependencyRegistrator :IDependencyRegistrator
    {
        public void Register(IDependencyContainer container, IDependencyResolver resolver)
        {
            container.RegisterSingletonType<ICommandProvider, TextCommandProvider>("text_commands");       
        }
    }
}