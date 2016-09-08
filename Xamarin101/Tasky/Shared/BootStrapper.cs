// <copyright file="BootStrapper.cs" company="Fendustries">
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
// Original project and code from https://github.com/xamarin/mobile-samples/tree/master/Tasky authored by Bryan Costanich, Craig Dunn
//
// Last modified by Joshua Fenemore 11/10/2015
//
// </copyright>

namespace Shared
{
    using Autofac;
    using Tasky.Interfaces;
    using Tasky.Managers;
    using Tasky.Models;
    using Tasky.Repository;

    /// <summary>
    /// Public class BootStrapper. This class is responsible for all our dependancy injection needs.
    /// </summary>
    public static class BootStrapper
    {
        /// <summary>
        /// Holds a reference to the IoC container
        /// </summary>
        private static IContainer Container { get; set; }
        
        /// <summary>
        /// Initialises the <see cref="BootStrapper"/> class.
        /// </summary>
        static BootStrapper()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            containerBuilder.Register(n => new TaskItem()).As<ITaskItem>();
            containerBuilder.RegisterType<TaskRepository>().As<ITaskRepository>().SingleInstance();
            containerBuilder.RegisterType<HomeViewModel>().As<IHomeViewModel>().SingleInstance();
            containerBuilder.RegisterType<TaskDetailsViewModel>().As<ITaskDetailsViewModel>().SingleInstance();

            Container = containerBuilder.Build();
        }

        /// <summary>
        /// The method used to resolve all the dependancies
        /// </summary>
        /// <typeparam name="T">The type object we are resolving</typeparam>
        /// <returns>The implementation of the type {T}</returns>
        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}