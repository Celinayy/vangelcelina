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
	}
})

module.exports = mongoose.model('Kategoria', kategoriaSchema, 'kategoriak')