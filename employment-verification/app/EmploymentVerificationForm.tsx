"use client";

import React, { useState } from 'react';
import axios from 'axios';
import './EmploymentVerificationForm.css'; // CSS styling file

const EmploymentVerificationForm: React.FC = () => {
    const [employeeId, setEmployeeId] = useState<string>('');
    const [companyName, setCompanyName] = useState<string>('');
    const [verificationCode, setVerificationCode] = useState<string>('');
    const [verificationResult, setVerificationResult] = useState<string | null>(null);
    const [error, setError] = useState<string | null>(null);

    const handleSubmit = async (event: React.FormEvent) => {
        event.preventDefault();
        setVerificationResult(null);
        setError(null);

        try {
            const response = await axios.post('http://localhost:5258/api/employee/verify-employment', {
                employeeId: parseInt(employeeId),
                companyName,
                verificationCode
            });
            setVerificationResult(response.data.verified ? "Verified" : "Not Verified");
        } catch (err) {
            setError("Error verifying employment. Check your input or Please try again later.");
        }
    };

  return (
    <div className="verification-container">
      <h2>Employment Verification</h2>
      <form className="verification-form" onSubmit={handleSubmit}>
        <label>
          Employee ID:
          <input
            type="number"
            value={employeeId}
            onChange={(e) => setEmployeeId(e.target.value)}
            required
            placeholder="Enter Employee ID"
          />
        </label>
        <label>
          Company Name:
          <input
            type="text"
            value={companyName}
            onChange={(e) => setCompanyName(e.target.value)}
            required
            placeholder="Enter Company Name"
          />
        </label>
        <label>
          Verification Code:
          <input
            type="text"
            value={verificationCode}
            onChange={(e) => setVerificationCode(e.target.value)}
            required
            placeholder="Enter Verification Code"
          />
        </label>
        <button type="submit">Verify</button>
      </form>
      {verificationResult && <p className="result">Result: <span className={verificationResult == "Verified" ? "Passed" : "Failed"}>{verificationResult}</span></p>}
      {error && <p style={{ color: "red" }}>{error}</p>}
    </div>
  );
};

export default EmploymentVerificationForm;
