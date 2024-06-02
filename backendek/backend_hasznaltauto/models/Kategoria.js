const mongoose = require('mongoose')

const kategoriaSchema = new mongoose.Schema({
  _id: {
    type: Number,
    required: true
  },
  nev: {
    type: String,
    required: true,
    unique: true,
    maxlength: [30, 'A név nem tartalmazhat 30 karakternél többet!'],
  }
})

module.exports = mongoose.model('Kategoria', kategoriaSchema, 'kategoriak')
