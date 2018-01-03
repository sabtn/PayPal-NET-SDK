using System;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Collections.Generic;
using BraintreeHttp;
using Xunit;
using PayPal.Test;
using System.Threading.Tasks;
using PayPal.Core;

namespace PayPal.Identity.Test
{
    [Collection("Identity")]
    public class UserConsentTest
    {
        [Fact]
        public void TestUserConsent()
        {
            var url = new UserConsent(TestHarness.environment())
                                .ResponseType("code")
                                .Scope("profile+email+openid+phone+address+https%3A%2F%2Furi.paypal.com%2Fservices%2Fpaypalattributes")
                                .RedirectUri("http%3A%2F%2Frequestbin.fullcontact.com%2F15a7bhu1")
                                .Build();
            Assert.Equal("https://www.sandbox.paypal.com/signin/authorize?client_id=AdV4d6nLHabWLyemrw4BKdO9LjcnioNIOgoz7vD611ObbDUL0kJQfzrdhXEBwnH8QmV-7XZjvjRWn0kg&response_type=code&scope=profile+email+openid+phone+address+https%3A%2F%2Furi.paypal.com%2Fservices%2Fpaypalattributes&redirect_uri=http%3A%2F%2Frequestbin.fullcontact.com%2F15a7bhu1&", url);
        }

        [Fact]
        public async void TestGetRefreshTokenFromCode()
        {
            RefreshTokenRequest request = new RefreshTokenRequest(TestHarness.environment(), "C21AAGx1zkQq3kJ8ncjFgiVkahJMHwazeYmVsLhZNbcdHW8Gbk0NfNj15iqmUjChp5stXjJENcHedRG627GvbwXhj2Byg3G_Q");
            HttpResponse response = null;
            response = await TestHarness.client().Execute(request);
            Assert.NotNull(response);
            Assert.Equal(200, (int) response.StatusCode);
            Assert.NotNull(response.Result<RefreshToken>());
            var actual = response.Result<RefreshToken>();
            Assert.Equal("123", actual.Token);
        }

        [Fact]
        public async void TestUserinfoGetRequest()
        {
            var refreshToken = "R23AAE931QdisRpq7GmGt268N8zJUVUdAj9XXD_zidu45NU3wYwdTdGdy9r7J8wKpnsACzui_3DCAexGK3eG0a_YA5x7W_BkQde9SCMx3fOqod8HlrK36De-j3f5IcD9_BkAnN9NI8Kr-uxa2zzMQ";
            var request = new UserinfoGetRequest().Schema("openid");
            var client = TestHarness.client(refreshToken);

            HttpResponse response = await client.Execute(request);
            Assert.Equal(200, (int) response.StatusCode);
            Assert.NotNull(response.Result<UserInfo>());
            var actual = response.Result<UserInfo>();
            Assert.Equal("Sample Buyer", actual.Name);
            Assert.Equal("samplebuyer@buy.com", actual.Email);
            Assert.Equal("Sample", actual.GivenName);
            Assert.Equal("4084891074", actual.PhoneNumber);
            Assert.NotNull(actual.Address);
            Assert.Equal("San Jose", actual.Address.Locality);
        }
    }
}
