const mongoose = require("mongoose");

const ingatlanSchema = new mongoose.Schema({
  _id: {
    type: Number,
    required: true,
  },
  kategoria: {
    type: Number,
    ref: "Kategoria",
  },
  leiras: {
    type: String,
  },
  hirdetesDatuma: {
    type: Date,
    default: () => {
      return Date.now();
    },
  },
  tehermentes: {
    type: Boolean,
    required: true,
  },
  ar: {
    type: Number,
    required: true,
  },
  kepUrl: {
    type: String,
  },
});

module.exports = mongoose.model("Ingatlan", ingatlanSchema, "ingatlanok");

