using Xunit;
using CoreMVCBackend.Utility;

namespace CoreMvcBackend.UnitTest{
    public class EncodeHelperTest{

        public void EncodeSuccess(){
            string sample="27-3A-0C-7B-D3-C6-79-BA-9A-6F-5D-99-07-8E-36-E8-5D-02-B9-52";

            Assert.Equal(sample,EncodeHelper.Encode(EncodeEnum.SHA1,"222222"));
        }

        [Fact]
        public void EncodeSuccessSHA256(){
            string sample="4C-C8-F4-D6-09-B7-17-35-67-01-C5-7A-03-E7-37-E5-AC-8F-E8-85-DA-8C-71-63-D3-DE-47-E0-18-49-C6-35";

            Assert.Equal(sample,EncodeHelper.Encode(EncodeEnum.SHA256,"222222"));
        }
    }
}