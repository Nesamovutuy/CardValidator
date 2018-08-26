import React, { Component } from 'react';
import './Home.css';

export class Home extends Component {
  displayName = Home.name

  constructor(props) {
    super(props);
    this.state = { result: null, error: null };
    this.validate = this.validate.bind(this);
  }

  validate() {
    fetch('api/Payment/Card', {
      method: 'post',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({
        "Number": this.cardNumber.value,
        "Month": this.exprMonth.value,
        "Year": this.exprYear.value
      })
    })
    .then(response => {
      if (response.ok) {
        return response.json();
      } else if (response.status === 404) {
        throw new Error("Doesn't exists");
      } else {
        throw new Error("Invalid");
      }
    })
    .then(data => {
      this.setState({ result: data, error: null });
    })
    .catch(error => {
      this.setState({ error: error.message, result: null })
    });
  }

  static renderResult(result) {
    return (
      <div class="alert alert-success" role="alert">Valid: {result.cardType}</div>
    );
  }

  static renderError(error) {
    return (
      <div class="alert alert-danger" role="alert">{error}</div>
    );
  }

  render() {
    let result = this.state.result
      && Home.renderResult(this.state.result);
    let error = this.state.error
      && Home.renderError(this.state.error);

    return (
      <div>
        <h1>Card Validation</h1>
        <div class="input-group input-group-sm mb-3 card-input">
          <div class="input-group-prepend">
            <span class="input-group-text" id="inputGroup-sizing-sm">Card Number</span>
          </div>
          <input ref={(ref) => {this.cardNumber = ref}} type="text" class="form-control" />
        </div>
        <div class="input-group input-group-smmb-3">
          <div class="input-group-prepend">
            <span class="input-group-text" id="inputGroup-sizing-sm">Expiry Date</span>
          </div>
          <div class="expr-inputs">
            <input ref={(ref) => {this.exprMonth = ref}} type="number" min="1" max="12" class="form-control" placeholder="MM" />
            <span class="separator">/</span>
            <input ref={(ref) => {this.exprYear = ref}} type="number" min={(new Date().getFullYear())} class="form-control" placeholder="YYYY" />
          </div>
        </div>
        <button type="button" class="btn btn-primary btn-margin" onClick={this.validate}>Validate</button>
        {result}
        {error}
      </div>
    );
  }
}
