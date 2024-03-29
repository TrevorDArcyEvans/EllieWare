// Copyright 2007-2012 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace Topshelf.Supervise
{
    using HostConfigurators;
    using ServiceConfigurators;

    /// <summary>
    /// Configures the service that is to be supervised, including any of the parameters
    /// of the supervision service
    /// </summary>
    public interface SuperviseConfigurator :
        ServiceConfigurator
    {
        /// <summary>
        ///   Sets the service builder to use for creating the service
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="serviceBuilderFactory"> </param>
        void UseServiceBuilder(ServiceBuilderFactory serviceBuilderFactory);
    }
}