import React, { Component } from 'react';
import * as axios from 'axios';
import { API_REGISTER } from '../common/constants';

export class Register extends Component {
    constructor(props) {
        super(props);
        this.state = { email: '', password: '', confirmPassword: '' };
    }

    tryRegister() {
        const data = JSON.stringify({
            email: '4teste00@mail.com',
            password: 'HE@E20qwe123',
            confirmPassword: 'HE@E20qwe123'
        });
        axios.post('api/Account/Register', data, { headers: { 'Content-Type': 'application/json' } })
            .then(function (response) {
                console.log(response);
            })
            .catch(function (error) {
                console.log(error);
            });
    }

    render() {
        return (
            <div>
                <h1>Login</h1>
                <form>
                    <input placeholder="E-mail" value={this.state.email} />
                    <br />
                    <input placeholder="Password" type="password" value={this.state.password} />
                    <br />
                    <input placeholder="Confirm password" type="password" value={this.state.confirmPassword} />
                    <br />
                    <button onClick={this.tryRegister} type="button">Register</button>
                </form>
            </div>
        );
    }
}