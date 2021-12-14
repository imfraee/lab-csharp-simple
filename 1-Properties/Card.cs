namespace Properties
{
    using System;

    /// <summary>
    /// The class models a card.
    /// </summary>
    public class Card
    {
        private readonly string seed;
        private readonly string name;
        private readonly int ordinal;

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="name">the name of the card.</param>
        /// <param name="seed">the seed of the card.</param>
        /// <param name="ordinal">the ordinal number of the card.</param>
        public Card(string name, string seed, int ordinal)
        {
            this.name = name;
            this.ordinal = ordinal;
            this.seed = seed;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="tuple">the informations about the card as a tuple.</param>
        internal Card(Tuple<string, string, int> tuple) 
            : this(tuple.Item1, tuple.Item2, tuple.Item3)
        {
        }

        public string Seed {
            get{ return this.seed };
        }
        public string Name => this.name;
    
        public int Ordinal => this.ordinal;

        /// <inheritdoc cref="object.ToString"/>
        public override string ToString() => $"{this.GetType().Name}(Name={this.GetName()}, Seed={this.GetSeed()}, Ordinal={this.GetOrdinal()})";

        /// <inheritdoc cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(Card other)
        {
            return string.Equals(this.seed, other.seed)
                && string.Equals(this.name, other.name)
                && this.ordinal == other.ordinal;
        }

        /// <inheritdoc cref="object.Equals(object?)"/>>
        public override bool Equals(object obj) {

            if (obj is null) return false;

            if (this == obj) return true;

            if (obj.GetType != this.GetType) return false;

            return this.Equals(obj as Card);
        }
        /// <inheritdoc cref="object.GetHashCode"/>>
        public override int GetHashCode() => Hashcode.Combine(this.name, this.ordinal, this.seed);
    }
}
