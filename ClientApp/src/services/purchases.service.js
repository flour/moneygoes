import { prepareHeaders, handleResponse, handleError, config } from '../common';

export const purchasesService = {
    getAllPurchases: async () => {
        const requestOptions = { method: 'GET', headers: prepareHeaders(true, true) };
        try {
            const response = await fetch(config.purchasesUrl, requestOptions);
            const data = await handleResponse(response);
            if (data) {
                localStorage.setItem('purchases', JSON.stringify(data));
            }
            return data;
        }
        catch (error) {
            handleError(error);
            throw error;
        }
    },
    createPurchase: async (name, description) => {
        const requestOptions = {
            method: 'POST',
            headers: prepareHeaders(true, true),
            body: JSON.stringify({ name, description })
        };
        try {
            const response = await fetch(config.purchasesUrl, requestOptions);
            const data = await handleResponse(response);
            if (data) {
                let allPayments = JSON.parse(localStorage.getItem('purchases'));
                allPayments = [data, ...allPayments];
                localStorage.setItem('purchases', JSON.stringify(allPayments));
            }
            return data;
        } catch (error) {
            handleError(error);
            throw error;
        }
    }
}
