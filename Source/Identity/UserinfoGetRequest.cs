// This class was generated on Wed, 13 Dec 2017 14:32:41 CST by version 0.1 of Braintree SDK Generator
// UserinfoGetRequest.cs
// @version 0.1
// @type request
// @data H4sIAAAAAAAC/8RYTW/bOBO+v79iwPewF1l2uzfdgrjdBmjabJsWCHYLmxZH1mwoUiVHTtWi/31BUjYSx26y2Kx6SczhDPXMQ84H+U28kQ2KQnQeHZnK5mtkkYk5+tJRy2SNKMT72t54CCqgkCVpn//ZzWa/litty+vPnWWM4/S39OysWSfJG8tYJPH0thwua/JwcnEG5EFh67CUjCqHDx5huXk2tbLj+vmU7TWa6RbdEsh4RqmG70/3AYhM/N6h6y+kkw0yOi+KP76Jy74NTnp2ZNYiEx+lI7nSODjvyxobec/tl6TDCsA1gkPfWuMRVj1ISAawkbrDHD5KTSoNgjdL26IhtcxFJk6ck336+iwT71Cqt0b3oqik9hgEnztyqETBrsNMXDjbomNCLwrTaf39UyZeoVTo7jj0KRMvrWv2ZReS631Z+AJ6ThDCkkGUXEmyHTmB40Ug+T4/95h526KBszmcWmOw5HQ0gq1rZFDJlS27Bg3H0Wsy10XN3BbTaeImN8hT32LpB8GkTCtNVtJTOXm2mOU1N/r/71kaJZ061ZIa/08IHQS3GX34IMiytJ3hBQe1fadPDKDpGnTRKbBVPBiDCQQTn/9LhHHPs7tbIpVy6P0BsLuJuzgvawQ0Km7KLx5ahxU6hwoGg/w/pzEy4vqDyIa5J2bqGBJtS6mJj0Ah7sE62CqNhKm1nqVelFbhQVhfqYUwGaAl3TgcCZ3DdYByCJhnyZhB6+yGTBl/YYUldw6zADaZjoTTs0PkxY+CoOq0hqS3O/twKg2QKXWnMMZvbTuPYLpmhQ6kUVsDI5unofzTI5yRa1w4adaHD8Q2xdRWqxjSco0Q1UfiekWOayUZH8o1g2KfARlYXl1dXU3Ozyfz+RJSacghGPQoHZyfXMEKYTmbzWbLDG5qKmsgoyj0AaHmSo77E5XJg22IY4NwacGFfsGjYbBG9zu1LMCIo/jp3UfHIQkbSfrxyRgnQf+pcvIexpW1GqU5AnKxQUcVobqH9mzH/02NXKOLbN7Cj7dBh23ZLjUSyZVsSPeLEJyHU1TnwlxMR1r6FMZhEP77bFu0tx6NhHqNRqF76GwkrbEg0QbNcR7jdGSxIuc5u8vjT6Ix1ukHc1DSGglSQ0ppPM5jmh/Y+ymkHYV2i7JYKCNGMqDIt1r2YYmYQIdqSWYNcqvWSsc+hwvrPa10vy2oHphYo091tKsq+oIevHUcus+ytC4uw3Y/raQ9i2YpQ6Ipn7ybPtqPyT7cfNRBls7m+41+VB8LWm0NLlJz8vjSwqgxWg5tzVhgKbaCB3F+ePd6//xHyLYijTBYjtU5dqsjtWP1V7jMns3Dub+DFYZmhLzvRuMzXcgfOpajQDzaT2zL/2KIjoNgt0q7EAoXiW6s8P5qDQ7PGj+MH6YGISg/VdcvTq1hNMPbixCZeMXcniPXVolC/PbiUqQ3G1GI6ebZlBQaJu6HJ5HhRWT39iUy8eJLiyWjeh/5Ow0XyOL5bPb9f38DAAD//w==
// DO NOT EDIT
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using BraintreeHttp;

namespace PayPal.Identity
{
    /// <summary>
    /// Shows user details.<blockquote><strong>Note:</strong> This API is deprecated. Use `v1/oauth2/token/userinfo` instead.</blockquote>
    /// </summary>
    public class UserinfoGetRequest : HttpRequest
    {
        public UserinfoGetRequest() : base("/v1/identity/openidconnect/userinfo?", HttpMethod.Get, typeof(UserInfo))
        {
			this.ContentType = "application/x-www-form-urlencoded";
        }

        public UserinfoGetRequest Schema(string Schema)
        {
            var strParams = Convert.ToString(Schema);
            try {
                this.Path = $"{this.Path}schema={Uri.EscapeDataString(strParams)}&";
            } catch (IOException) {}
            return this;
        }
        
        
    }
}
