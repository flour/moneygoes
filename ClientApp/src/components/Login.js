import React, { Component } from 'react';
import * as axios from 'axios';

export class Login extends Component {
    constructor(props) {
        super(props);
        this.state = { email: '', password: '', error: '' };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(event) {
        this.setState({ [event.target.name]: event.target.value });
    }

    handleSubmit() {
        this.state.error = '';
        const data = JSON.stringify({
            email: this.state.email,
            password: this.state.password
        });
        axios.post('api/Account/Login', data, { headers: { 'Content-Type': 'application/json' } })
            .then(response => {
                console.log(response);
            })
            .catch(error => {
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
                        type="password"
                        name="password"
                        value={this.state.password}
                        onChange={this.handleChange} />
                    <br />
                    <input type="button" value="Login" onClick={this.handleSubmit} />
                </form>
                <div>{this.state.error}</div>
            </div>
        );
    }
}
