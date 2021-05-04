namespace DBMovies.model
{
    class Cast
    {
        public decimal id { get; set; }
        public string fullName { get; set; }
        public string role { get; set; }

        public Cast(decimal id, string fullName, string role)
        {
            this.id = id;
            this.fullName = fullName;
            this.role = role;
        }

        public override string ToString()
        {
            return string.Format(
                "Name: {0}\nRole: {1}",
                fullName, role);
        }
    }
}
