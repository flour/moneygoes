import React, { Component } from 'react';
import * as axios from 'axios';
import { API_REGISTER } from '../common/constants';

export class Register extends Component {
    constructor(props) {
        super(props);
        this.state = { email: '', password: '', confirmPassword: '', error: '' };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(event) {
        this.setState({ [event.target.name]: event.target.value });
    }

    handleSubmit() {
        this.state.error = API_REGISTER;
        const data = JSON.stringify({
            email: this.state.email,
            password: this.state.password,
            confirmPassword: this.state.confirmPassword
        });
        axios.post('api/Account/Register', data, { headers: { 'Content-Type': 'application/json' } })
            .then(function (response) {
                console.log(response);
            })
            .catch(function (error) {
                console.log(error);
                this.setState({ error: error.response.data.data });
            });
    }

    render() {
        return (
            <div>
                <h1>Login</h1>
                <form>
                    <input placeholder="E-mail"
                        name="email"
                        value={this.state.email}
                        onChange={this.handleChange} />
                    <br />
                    <input placeholder="Password"
                        type="password" name="password"
                        value={this.state.password}
                        onChange={this.handleChange} />
                    <br />
                    <input placeholder="Confirm password"
                        type="password"
                        name="confirmPassword"
                        value={this.state.confirmPassword}
                        onChange={this.handleChange} />
                    <br />
                    <button onClick={this.handleSubmit} type="button">Register</button>
                </form>
                <div>{this.state.error}</div>
            </div>
        );
    }
}