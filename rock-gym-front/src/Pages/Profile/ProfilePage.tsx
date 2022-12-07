import React from "react";

const ProfilePage = () => {
    return (
        <div className="row g-3">
            <div className="col-sm-6">
              <label className="form-label">Vardas</label>
              <input type="text" className="form-control" id="firstName" placeholder="" value=""/>
              {/* <div className="invalid-feedback">
                Valid first name is required.
              </div> */}
            </div>

            <div className="col-sm-6">
              <label className="form-label">Pavardė</label>
              <input type="text" className="form-control" id="lastName" placeholder="" value=""/>
              {/* <div className="invalid-feedback">
                Valid last name is required.
              </div> */}
            </div>

            <div className="col-12">
              <label className="form-label">Email <span className="text-muted">(Optional)</span></label>
              <input type="email" className="form-control" id="email" placeholder="you@example.com"/>
              {/* <div className="invalid-feedback">
                Please enter a valid email address for shipping updates.
              </div> */}
            </div>

            <div className="col-12">
              <label className="form-label">Address</label>
              <input type="text" className="form-control" id="address" placeholder="1234 Main St"/>
              {/* <div className="invalid-feedback">
                Please enter your shipping address.
              </div> */}
            </div>

            <div className="col-md-5">
              <label className="form-label">Country</label>
              <select className="form-select" id="country">
                <option value="">Choose...</option>
                <option>United States</option>
              </select>
              {/* <div className="invalid-feedback">
                Please select a valid country.
              </div> */}
            </div>
          </div>
    );
};
export { ProfilePage };