namespace aspPopravni.API
{
    public class AppSettings
    {
        public string ConnectionString { get; set; } = "Data Source=.\\SQLEXPRESS;Initial Catalog=PopravniASP;Integrated Security=True;Trust Server Certificate=True";
        public JwtSettings Jwt { get; set; }
        public string PasswordSalt { get; set; }
    }
    public class JwtSettings
    {
        public string SecretKey { get; set; } = "597e3b12820151caa6062612caec8056";
        public int DurationSeconds { get; set; }
        public string Issuer { get; set; }
    }
}
