﻿// Copyright 2007-2012 Chris Patterson, Dru Sellers, Travis Smith, et. al.
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
namespace Topshelf.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class Configuring_service_events
    {
        [Test]
        public void Should_result_in_them_being_called()
        {
            bool beforeStart = false;
            bool afterStart = false;
            bool beforeStop = false;
            bool afterStop = false;

            HostFactory.Run(x =>
                {
                    x.UseTestHost();

                    x.Service(settings => new MyService(), s =>
                        {
                            s.BeforeStartingService(() => { beforeStart = true; });
                            s.AfterStartingService(context => { afterStart = true; });

                            s.BeforeStoppingService(context => { beforeStop = true; });
                            s.AfterStoppingService(() => { afterStop = true; });
                        });
                });

            Assert.IsTrue(beforeStart);
            Assert.IsTrue(afterStart);
            Assert.IsTrue(beforeStop);
            Assert.IsTrue(afterStop);
        }

        [Test]
        public void Should_call_the_service_event_method()
        {
            bool beforeStart = false;
            bool afterStart = false;
            bool beforeStop = false;
            bool afterStop = false;

            HostFactory.Run(x =>
                {
                    x.UseTestHost();

                    x.Service(() => new MyService(), s =>
                        {
                            s.BeforeStartingService(() => { beforeStart = true; });
                            s.AfterStartingService(context => { afterStart = true; });

                            s.BeforeStoppingService(context => { beforeStop = true; });
                            s.AfterStoppingService(() => { afterStop = true; });
                        });
                });

            Assert.IsTrue(beforeStart);
            Assert.IsTrue(afterStart);
            Assert.IsTrue(beforeStop);
            Assert.IsTrue(afterStop);
        }

        [Test]
        public void Should_call_for_delegate_services_too()
        {
            bool beforeStart = false;
            bool afterStart = false;
            bool beforeStop = false;
            bool afterStop = false;

            HostFactory.Run(x =>
                {
                    x.UseTestHost();

                    x.Service<MyService>(s =>
                        {
                            s.ConstructUsing(() => new MyService());
                            s.WhenStarted((service, host) => service.Start(host));
                            s.WhenStopped((service, host) => service.Stop(host));

                            s.BeforeStartingService(() => { beforeStart = true; });
                            s.AfterStartingService(context => { afterStart = true; });

                            s.BeforeStoppingService(context => { beforeStop = true; });
                            s.AfterStoppingService(() => { afterStop = true; });
                        });
                });

            Assert.IsTrue(beforeStart);
            Assert.IsTrue(afterStart);
            Assert.IsTrue(beforeStop);
            Assert.IsTrue(afterStop);
        }

        class MyService : ServiceControl
        {
            public bool Start(HostControl hostControl)
            {
                return true;
            }

            public bool Stop(HostControl hostControl)
            {
                return true;
            }
        }
    }
}