namespace test
{
    public class testing
    {
        public static bool test()
        {
            string str1 = "abacaba$";
            string str2 = "abracadabra$";
            string str3 = "hello$";
            return UserFile.t.Solution(str1) == "abc$baaa" && UserFile.t.Solution(str2) == "ard$rcaaaabb" && UserFile.t.Solution(str3) == "oh$ell";
        }
    }
}
