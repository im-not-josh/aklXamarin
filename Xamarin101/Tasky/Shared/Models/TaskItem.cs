// <copyright file="TaskItem.cs" company="Fendustries">
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
// Original project and code from https://github.com/xamarin/mobile-samples/tree/master/Tasky authored by Bryan Costanich, Craig Dunn
//
// Last modified by Joshua Fenemore 11/10/2015
//
// </copyright>

namespace Tasky.Models
{
    using Interfaces;

    /// <summary>
    /// Public class TaskItem. The concrete implementation of the <see cref="ITaskItem"/> interface. Inherits from <see cref="BusinessEntityBase"/>.
    /// </summary>
	public class TaskItem : BusinessEntityBase, ITaskItem
	{
        /// <summary>
        /// Initialises a new instance of the <see cref="TaskItem"/> class.
        /// </summary>
		public TaskItem ()
		{
		}

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
		public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Notes
        /// </summary>
		public string Notes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this task entity is done or not
        /// </summary>
		public bool Done { get; set; }
	}
}