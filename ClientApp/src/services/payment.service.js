import { prepareHeaders, handleResponse, handleError, config } from '../common';

export const paymentService = {
    getAllGroups: async () => {
        const requestOptions = { method: 'GET', headers: prepareHeaders(true, true) };
        try {
            const response = await fetch(config.paymentsUrl, requestOptions);
            const data = await handleResponse(response);
            if (data) {
                localStorage.setItem('payments', JSON.stringify(data));
            }
            return data;
        }
        catch (error) {
            handleError(error);
            throw error;
        }
    },
    createGroup: async (name, description) => {
        const requestOptions = {
            method: 'POST',
            headers: prepareHeaders(true, true),
            body: JSON.stringify({ name, description })
        };
        try {
            const response = await fetch(config.paymentsUrl, requestOptions);
            const data = await handleResponse(response);
            if (data) {
                let allPayments = JSON.parse(localStorage.getItem('payments'));
                allPayments = [data, ...allPayments];
                localStorage.setItem('payments', JSON.stringify(allPayments));
            }
            return data;
        } catch (error) {
            handleError(error);
            throw error;
        }
    }
}
